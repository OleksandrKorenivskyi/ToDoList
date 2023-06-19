import { combineReducers } from 'redux';
import { toDoListReducer } from './toDoList';
import { applicationReducer } from './application';

export default combineReducers({
  toDoList:  toDoListReducer,
  application: applicationReducer
});