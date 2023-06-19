import React from 'react';
import { Col, Row } from 'react-bootstrap';
import type { Task } from '../behavior/types';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faTrashAlt } from '@fortawesome/free-solid-svg-icons';
import { faSquare, faSquareCheck } from '@fortawesome/free-regular-svg-icons';
import { useDispatch } from 'react-redux';
import { remove, toggleCompletion } from '../behavior/toDoList/actions';

type Props = {
  task: Task;
}

export const TaskItem = ({ task }: Props) => {
  const dispatch = useDispatch();

  return (
    <Row className='mb-4'>
      <Col className='col-auto'>
        <button className='task-checkbox-button' onClick={() => dispatch(toggleCompletion(task.id))}>
          <FontAwesomeIcon icon={task.completed ? faSquareCheck : faSquare} size='xl'
            className={task.completed ? 'task-completed-checkbox' : 'task-checkbox'} />
        </button>
      </Col>
      <Col>
        <p className='mb-0'>{task.description}</p>
        <p className='category-name mb-0'>{task.categoryName}</p>
      </Col>
      <Col>
        <p className={task.completed ? 'text-crossed' : ''}>{task.dueDate == null ? '' : `Due ${task.dueDate}`}</p>
      </Col>
      <Col className='col-auto'>
        <button className='task-delete-button' onClick={() => dispatch(remove(task.id))}>
          <FontAwesomeIcon icon={faTrashAlt} size='xl' />
        </button>
      </Col>
    </Row>
  );
};