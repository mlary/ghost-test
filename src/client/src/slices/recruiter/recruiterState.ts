import { RecruiterDto } from "~/app/ApiClient";
import LoadingState from "~/types/LoadingState";

export interface RecruiterState {
    getRecruiterLoading: LoadingState;
    createRecruiterLoading: LoadingState;
    targetRecruiter: RecruiterDto | null;
    errorMessage?:string;
}
export const initialRecruiterState: RecruiterState = {
    getRecruiterLoading: LoadingState.idle,
    targetRecruiter: null,
    createRecruiterLoading: LoadingState.idle,
}
