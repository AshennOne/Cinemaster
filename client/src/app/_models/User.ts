import { Like } from "./Like";

export interface User {
  id?: number;
  userName: string;
  imgUrl?: string;
  password?: string;
  token?: string;
  likedMovies?: Like[]
}
