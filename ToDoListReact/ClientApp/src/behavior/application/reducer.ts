import { createReducer } from '@reduxjs/toolkit';
import {
  DATA_STORAGE_TYPE_SELECTED,
  ApplicationActions
} from './actions';
import { StorageType } from '../types';

type State = { storageType: StorageType };

export const initialState: State = {
  storageType: StorageType.Database,
};

export default createReducer(initialState, {
  [DATA_STORAGE_TYPE_SELECTED]: onSelect
});

function onSelect(state: State, action: ApplicationActions) {
  const { type } = action.payload;

  return { ...state, storageType: type };
}