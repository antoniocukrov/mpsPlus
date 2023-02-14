import { Article } from "./article.model";
import { Employee } from "./employee.model";

export interface Receipt {
    id: string;
    name: string;
    receiptNumber: number;
    employee: Employee;
    articles: Article[];
}