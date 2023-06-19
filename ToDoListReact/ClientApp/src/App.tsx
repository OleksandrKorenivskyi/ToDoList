import React, { useEffect } from 'react';
import { CreateTaskForm, DataStorageTypeForm} from './components';
import { Container, Navbar } from 'react-bootstrap';
import { TaskList } from './components/TaskList';
import { requestCategories } from './behavior/toDoList/actions';
import { useDispatch, useSelector } from 'react-redux';
import { RootState } from './behavior/store';

const App = () => {
  const dispatch = useDispatch();
  const categories = useSelector((state: RootState) => state.toDoList.categories);
  useEffect(() => { dispatch(requestCategories()); }, [dispatch]);
  return (
    <>
      <header>
        <Navbar className='navbar bg-white border-bottom mb-3'>
          <div className='container-fluid '>
            <span className='navbar-brand'>ToDoList</span>
            <DataStorageTypeForm />
          </div>
        </Navbar>
      </header>
      <Container className='to-do-list'>
        <CreateTaskForm categories={categories} />
        <TaskList />
      </Container>
    </>
  );
};

export default App;