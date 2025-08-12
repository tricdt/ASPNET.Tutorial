export class AppFunction {
  id: string;
  name: string;
  url: string;
  sortOrder: number;
  parentId: string | null;
  icon: string;
  separator?: boolean;
  visible?: boolean;
  children?: AppFunction[] | null;
}
