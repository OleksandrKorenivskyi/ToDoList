import type { StorageType } from '../types';

export const DATA_STORAGE_TYPE_SELECTED = 'DATA_STORAGE_TYPE_SELECT';
export const selectStorageType = (type: StorageType) => ({
  type: DATA_STORAGE_TYPE_SELECTED,
  payload: { type }
});

export type ApplicationActions = ReturnType<typeof selectStorageType>;