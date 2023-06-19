import { createReducer } from '@reduxjs/toolkit';
import {
  TASK_CREATE,
  TASK_TOGGLE_COMPLETION,
  TASK_REMOVE,
  TaskCreateAction,
  TaskToggleCompletionAction,
  TaskRemoveAction,
} from './actions';
import type { Task } from '../types';
import { createTask, sortTasks } from '../helpers';

export type ToDoListState = { tasks: Task[] };

const initialState: ToDoListState = {
  tasks: []
};

export default createReducer(initialState, {
  [TASK_CREATE]: onCreate,
  [TASK_TOGGLE_COMPLETION]: onToggleCompletion,
  [TASK_REMOVE]: onDelete,
});

function onCreate(state: ToDoListState, action: TaskCreateAction) {
  const { taskInput } = action.payload;
  const task = createTask(taskInput);
  const tasks = [...state.tasks, task];

  return { ...state, tasks: sortTasks(tasks) };
}

function onDelete(state: ToDoListState, action: TaskRemoveAction) {
  const { taskId } = action.payload;

  return { ...state, tasks: state.tasks.filter(task => task.id !== taskId) };
}

function onToggleCompletion(state: ToDoListState, action: TaskToggleCompletionAction) {
  const { taskId } = action.payload;
  const tasks = state.tasks.map(task => task.id === taskId ? { ...task, isCompleted: !task.isCompleted } : task);
  
  return { ...state, tasks: sortTasks(tasks) };
}