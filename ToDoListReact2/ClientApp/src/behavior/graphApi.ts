import { from } from 'rxjs';

export const sendRequest = (query: string, variables?: unknown) => {
  const path = 'https://localhost:7243/graphql';
  const body = JSON.stringify({ query, variables });

  return from(
    fetch(path,
      {
        headers:
          { 'Content-Type': 'application/graphql' },
        method: 'POST',
        body,
        mode: 'no-cors'
      }));
};