import type { StorageType } from '../types';

export const DATA_STORAGE_TYPE_SELECT = 'DATA_STORAGE_TYPE_SELECT';
export const select = (type: StorageType) => ({
  type: DATA_STORAGE_TYPE_SELECT,
  payload: { type }
});

export type DataStorageTypeAction = ReturnType<typeof select>;