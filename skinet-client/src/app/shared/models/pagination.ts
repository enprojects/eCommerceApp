
export interface IPagination<T> {
  data: T[];
  count: number;
  pageNumber: number;
  pageSize: number;
}
