import { from, map } from 'rxjs';
import { StorageType } from './types';

export const sendRequest = (query: string, storageType: StorageType, variables?: unknown,) => {
  const path = 'http://localhost:5000/graphql';
  const body = JSON.stringify({ query, variables });
  const headers = {
    'Content-Type': 'application/json',
    'DataStorage': storageType,
  };
  return from(
    fetch(path,
      {
        headers,
        method: 'POST',
        body,
        mode: 'cors'
      }).then(response => response.json())).pipe(
        map((response: { data: any; }) => response.data));
};