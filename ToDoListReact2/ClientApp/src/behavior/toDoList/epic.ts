import { mergeMap, tap, map } from 'rxjs';
import { ToDoListActions, TASK_LIST_REQUESTED, remove } from './actions';
//import { ToDoListState } from './reducer';
import { Epic, ofType } from 'redux-observable';
import { sendRequest } from '../graphApi';
import { getTasksQuery } from './queries';

const epic: Epic<ToDoListActions> = (actions$, state$) => {
  const requestTasks$ = actions$.pipe(
    ofType(TASK_LIST_REQUESTED),
    mergeMap(() => sendRequest(getTasksQuery).pipe(
      tap(response => console.dir(response)),
      map(response => remove('123')),
    )),
  );

  return requestTasks$;
};

export default epic;