import React, { useEffect } from 'react';
import { RootState } from '../behavior/store';
import { useDispatch, useSelector } from 'react-redux';
import { TaskItem } from './TaskItem';
import { requestTaskList } from '../behavior/toDoList/actions';

export const TaskList = () => {
  const dispatch = useDispatch();
  const tasks = useSelector((state: RootState) => state.toDoList.tasks);
  useEffect(() => { dispatch(requestTaskList()); }, [dispatch]);
  return (
    <>
      {tasks.map(task =>
        <TaskItem
          key={task.id}
          task={task}
        />)}
    </>
  );
};
