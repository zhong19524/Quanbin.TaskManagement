export interface TasksHistory {
    taskId: number;
    userId: number;
    title: string;
    description: string;
    dueDate: Date;
    completed: Date;
    remarks: string;
}