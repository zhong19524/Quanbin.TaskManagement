export interface TasksCreate {
    userId: number;
    title: string;
    description: string;
    dueDate: Date;
    priority: string;
    remarks: string;
}