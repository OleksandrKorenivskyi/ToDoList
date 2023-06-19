import { createReducer } from '@reduxjs/toolkit';
import {
  DATA_STORAGE_TYPE_SELECT,
  DataStorageTypeAction
} from './actions';
import type { StorageType } from '../types';

type State = { storageType: StorageType };

export const initialState: State = {
  storageType: { name: 'Database', value: 'Database' },
};

export default createReducer(initialState, {
  [DATA_STORAGE_TYPE_SELECT]: onSelect
});

function onSelect(state: State, action: DataStorageTypeAction) {
  const { type } = action.payload;

  return { ...state, storageType: state.storageType = type };
}