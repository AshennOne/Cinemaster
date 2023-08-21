import { Comment } from "./Comment";
import { Like } from "./Like";
import { Rating } from "./Rating";

export interface Movie {
  id?: number;
  title: string;
  genre: string;
  premiere: Date;
  description: string;
  imgUrl: string;
  duration: number;
  comments: Comment[];
  ratings: Rating[];
  likedByUsers:Like[]
}
