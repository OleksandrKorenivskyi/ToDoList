import React from 'react';
import type { Category, TaskInput } from '../behavior/types';
import { Col, Row } from 'react-bootstrap';
import { Formik, Form, Field } from 'formik';
import { useDispatch } from 'react-redux';
import { createTask } from '../behavior/toDoList/actions';
import { required } from '../behavior/validators';
import { ValidationMessage } from './forms/ValidationMessage';

type Props = {
  categories: Category[];
}

const initialValues: TaskInput = {
  description: null,
  categoryId: null,
  dueDate: null,
};

export const CreateTaskForm = ({ categories }: Props) => {
  const dispatch = useDispatch();
  const onSubmit = (values: TaskInput) => { dispatch(createTask(values)); };

  return (
    <>
      <Formik onSubmit={onSubmit} initialValues={initialValues}>
        <Form>
          <Row className="mb-2">
            <Col>
              <Field type="text" className='form-control text-box single-line' placeholder="Description" name={'description'} validate={required} />
              <ValidationMessage fieldName='description' />
            </Col>
            <Col>
              <Field type="datetime-local" className='form-control text-box single-line' name={'dueDate'} />
            </Col>
          </Row>
          <Row className="mb-5">
            <Col>
              <Field name={'categoryId'} className='form-control form-select' as='select' validate={required}>
                <option value="">Category</option>
                {categories.map(category => <option key={category.id} value={category.id}>{category.name}</option>)}
              </Field>
              <ValidationMessage fieldName='categoryId' />
            </Col>
            <Col className="text-end">
              <button className="btn btn-primary" type="submit">Add</button>
            </Col>
          </Row>
        </Form>
      </Formik>
    </>
  );
};
