import { UserDto } from "~/app/ApiClient";
import LoadingState from "~/types/LoadingState";

export interface UsersState{
    current: UserDto | null;
    authToken: string | null;
    users: UserDto[];
    loading: LoadingState;
    authLoading: LoadingState;
    userLoading: LoadingState;
}
export const initialUsersState: UsersState = {
    current: null,
    loading: LoadingState.idle,
    authLoading: LoadingState.idle,
    authToken: null,
    users: [],
    userLoading: LoadingState.idle,
}
