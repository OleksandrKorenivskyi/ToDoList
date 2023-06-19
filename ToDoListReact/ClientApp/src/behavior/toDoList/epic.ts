import { mergeMap, map, merge, tap } from 'rxjs';
import {
  ToDoListActions,
  receiveTaskList,
  receiveCategories,
  TASK_CREATE,
  TASK_TOGGLE_COMPLETION,
  TASK_REMOVE, requestTaskList,
  CATEGORIES_REQUESTED,
  TASK_LIST_REQUESTED
} from './actions';
import { Epic, ofType } from 'redux-observable';
import { sendRequest } from '../graphApi';
import { getTasksQuery, saveTaskMutation, deleteTaskMutation, toggleCompletionTaskMutation, getCategoriesQuery } from './queries';
import { ApplicationActions, DATA_STORAGE_TYPE_SELECTED } from '../application/actions';

const epic: Epic<ToDoListActions | ApplicationActions> = (actions$, state$) => {
  const requestTasks$ = actions$.pipe(
    ofType(TASK_LIST_REQUESTED, DATA_STORAGE_TYPE_SELECTED),
    mergeMap(() => sendRequest(getTasksQuery, state$.value.application.storageType).pipe(
      map(({ tasks }) => receiveTaskList(tasks.list))
    )),
  );

  const requestCategories$ = actions$.pipe(
    ofType(CATEGORIES_REQUESTED),
    mergeMap(() => sendRequest(getCategoriesQuery, state$.value.application.storageType).pipe(
      map(({ categories }) => receiveCategories(categories.list))
    )),
  );

  const createTask$ = actions$.pipe(
    ofType(TASK_CREATE),
    map(action => action.payload),
    mergeMap(({ taskInput }) => sendRequest(saveTaskMutation, state$.value.application.storageType, { input: taskInput }).pipe(
      map(() => requestTaskList())
    ))
  );

  const toggleCompletion$ = actions$.pipe(
    ofType(TASK_TOGGLE_COMPLETION),
    map(action => action.payload),
    mergeMap(({ taskId }) => sendRequest(toggleCompletionTaskMutation, state$.value.application.storageType, { id: taskId }).pipe(
      map(() => requestTaskList())
    ))
  );

  const deleteTask$ = actions$.pipe(
    ofType(TASK_REMOVE),
    tap(() => console.dir(state$.value)),
    map(action => action.payload),
    mergeMap(({ taskId }) => sendRequest(deleteTaskMutation, state$.value.application.storageType, { id: taskId }).pipe(
      map(() => requestTaskList())
    ))
  );

  return merge(requestTasks$, requestCategories$, toggleCompletion$, deleteTask$, createTask$);
};

export default epic;