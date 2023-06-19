import { createReducer } from '@reduxjs/toolkit';
import {
  TASK_LIST_RECEIVED,
  TaskListReceivedAction,
  CategoriesReceivedAction,
  CATEGORIES_RECEIVED,
} from './actions';
import type { Category, Task } from '../types';

export type ToDoListState = { tasks: Task[], categories: Category[] };

const initialState: ToDoListState = {
  tasks: [],
  categories: []
};

export default createReducer(initialState, {
  [TASK_LIST_RECEIVED]: onTasksReceived,
  [CATEGORIES_RECEIVED]: onCategoriesReceived
});

function onTasksReceived(state: ToDoListState, action: TaskListReceivedAction) {
  const { tasks } = action.payload;

  return { ...state, tasks };
}

function onCategoriesReceived(state: ToDoListState, action: CategoriesReceivedAction) {
  const { categories } = action.payload;

  return { ...state, categories };
}