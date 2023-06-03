import { RecaptchaDto } from "~/app/ApiClient";
import LoadingState from "~/types/LoadingState";

export interface RecaptchaState{
    result: RecaptchaDto | null;
    loading: LoadingState;
}
export const initialRecaptchaState: RecaptchaState = {
    loading: LoadingState.idle,
    result: null,
};
