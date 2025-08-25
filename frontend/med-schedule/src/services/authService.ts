import api from "@/lib/axios";
import { User } from '@/types/IUser';
import { LoginDTO, RegisterDTO } from '@/types/auth.dto';

export const authService = {
  login: (data: LoginDTO) => api.post<User>("/auth/login", data),
  register: (data: RegisterDTO) => api.post<User>("/auth/register", data),
};
