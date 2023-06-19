import React from 'react';
import { Col, Row, Button } from 'react-bootstrap';
import { StorageType } from '../behavior/types';
import { Formik, Form, Field } from 'formik';
import { useDispatch, useSelector } from 'react-redux';
import { selectStorageType } from '../behavior/application/actions';
import { RootState } from '../behavior/store';

type FormValues = {
  storageType: string,
}

export const DataStorageTypeForm = () => {
  const dispatch = useDispatch();
  const onSubmit = (values: FormValues) => { dispatch(selectStorageType(values.storageType as StorageType)); };
  const storageType = useSelector((state: RootState) => state.application.storageType);
  const initialValues = {
    storageType
  };

  return (
    <>
      <Formik onSubmit={onSubmit} initialValues={initialValues}>
        <Form>
          <Row>
            <Col>
              <Field name={'storageType'} className='form-control form-select' as='select'>
                <option key={StorageType.Database} value={StorageType.Database}>{'Database'}</option>
                <option key={StorageType.XmlFile} value={StorageType.XmlFile}>{'XML file'}</option>
              </Field>
            </Col>
            <Col>
              <Button type="submit">Select</Button>
            </Col>
          </Row>
        </Form>
      </Formik>
    </>
  );
};
