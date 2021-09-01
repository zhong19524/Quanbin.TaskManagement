export interface TasksHistoryCreate {
    userId: number;
    title: string;
    description: string;
    dueDate: Date;
    completed: Date;
    remarks: string;
}