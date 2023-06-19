import type { TaskInput } from '../types';

export const TASK_CREATE = 'TASK_CREATE';
export const create = (taskInput: TaskInput) => ({
  type: TASK_CREATE,
  payload: { taskInput }
});

export const TASK_LIST_REQUESTED = 'TASK_LIST_REQUESTED';
export const requestTaskList = () => ({
  type: TASK_LIST_REQUESTED,
});

export const TASK_TOGGLE_COMPLETION = 'TASK_TOGGLE_COMPLETION';
export const toggleCompletion = (taskId: string) => ({
  type: TASK_TOGGLE_COMPLETION,
  payload: { taskId }
});

export const TASK_REMOVE = 'TASK_REMOVE';
export const remove = (taskId: string) => ({
  type: TASK_REMOVE,
  payload: { taskId }
});

export type TaskCreateAction = ReturnType<typeof create>;
export type TaskToggleCompletionAction = ReturnType<typeof toggleCompletion>;
export type TaskRemoveAction = ReturnType<typeof remove>;
export type ToDoListActions = ReturnType<
  | typeof requestTaskList
  | typeof create
  | typeof remove
  | typeof toggleCompletion>
// TaskCreateAction | TaskToggleCompletionAction | TaskRemoveAction;