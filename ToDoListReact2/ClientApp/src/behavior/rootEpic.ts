import { combineEpics } from 'redux-observable';
import { toDoListEpic } from './toDoList';


export default combineEpics(
  toDoListEpic,
);