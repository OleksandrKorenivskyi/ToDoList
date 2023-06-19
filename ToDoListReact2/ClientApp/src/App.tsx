import React from 'react';
import { CreateTaskForm, TaskItem, DataStorageTypeForm } from './components';
import { categories } from './data';
import { Container, Navbar } from 'react-bootstrap';
import { storageTypes } from './data';
import { RootState } from './behavior/store';
import { useSelector } from 'react-redux';

const App = () => {
  const tasks = useSelector((state: RootState) => state.toDoListReducer.tasks);
  return (
    <>
      <header>
        <Navbar className='navbar bg-white border-bottom mb-3'>
          <div className='container-fluid '>
            <span className='navbar-brand'>ToDoList</span>
            <DataStorageTypeForm storageTypes={storageTypes} />
          </div>
        </Navbar>
      </header>
      <Container className='to-do-list'>
        <CreateTaskForm categories={categories} />
        {tasks.map(task =>
          <TaskItem
            key={task.id}
            task={task}
          />)}
      </Container>
    </>
  );
};

export default App;