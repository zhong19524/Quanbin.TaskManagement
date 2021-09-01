export interface TasksUpdate {
    id:number;
    userId: number;
    title: string;
    description: string;
    dueDate: Date;
    priority: string;
    remarks: string;
}