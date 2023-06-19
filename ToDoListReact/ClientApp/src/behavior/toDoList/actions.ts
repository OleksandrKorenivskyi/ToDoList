import type { TaskInput, Task, Category } from '../types';

export const TASK_CREATE= 'TASK_CREATE' as const;
export const createTask = (taskInput: TaskInput) => ({
  type: TASK_CREATE,
  payload: { taskInput }
});

export const TASK_LIST_REQUESTED = 'TASK_LIST_REQUESTED' as const;
export const requestTaskList = () => ({
  type: TASK_LIST_REQUESTED,
});

export const TASK_LIST_RECEIVED = 'TASK_LIST_RECEIVED' as const;
export const receiveTaskList = (tasks: Task[]) => ({
  type: TASK_LIST_RECEIVED,
  payload: { tasks }
});

export const CATEGORIES_REQUESTED = 'CATEGORIES_REQUESTED' as const;
export const requestCategories = () => ({
  type: CATEGORIES_REQUESTED,
});

export const CATEGORIES_RECEIVED = 'CATEGORIES_RECEIVED' as const;
export const receiveCategories = (categories: Category[]) => ({
  type: CATEGORIES_RECEIVED,
  payload: { categories }
});

export const TASK_TOGGLE_COMPLETION = 'TASK_TOGGLE_COMPLETION' as const;
export const toggleCompletion = (taskId: string) => ({
  type: TASK_TOGGLE_COMPLETION,
  payload: { taskId }
});

export const TASK_REMOVE = 'TASK_REMOVE' as const;
export const remove = (taskId: string) => ({
  type: TASK_REMOVE,
  payload: { taskId }
});

export type TaskCreateAction = ReturnType<typeof createTask>;
export type TaskToggleCompletionAction = ReturnType<typeof toggleCompletion>;
export type TaskRemoveAction = ReturnType<typeof remove>;
export type TaskListReceivedAction = ReturnType<typeof receiveTaskList>;
export type CategoriesReceivedAction = ReturnType<typeof receiveCategories>;
export type ToDoListActions = ReturnType<
  | typeof requestTaskList
  | typeof createTask
  | typeof remove
  | typeof toggleCompletion
  | typeof receiveTaskList
  | typeof requestCategories
  | typeof receiveCategories>
// TaskCreateAction | TaskToggleCompletionAction | TaskRemoveAction;