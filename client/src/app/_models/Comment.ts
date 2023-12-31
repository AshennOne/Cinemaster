import { Movie } from "./Movie";
import { User } from "./User";

export interface Comment {
  id?: number;
  content: string;
  movieId: number;
  userId:number;
  createTime:Date;
}
