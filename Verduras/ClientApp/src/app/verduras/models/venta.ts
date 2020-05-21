import { Producto } from "./producto";

export class Venta {
    id: number;
    vendedor: string;
    productos: Producto[];
    total:number;
    utilidad:number;
    fecha:Date;
}