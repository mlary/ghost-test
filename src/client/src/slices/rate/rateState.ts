import { RateDto } from '~/app/ApiClient';
import LoadingState from '~/types/LoadingState';
import { RecruiterFields } from '~/types/recruiterFields';

export interface RateState {
  loading: LoadingState;
  createLoading: LoadingState;
  confirmLoading: LoadingState;
  result: RateDto | null;
  errorMessage?: string;
  recruiterData: RecruiterFields | null;
}
export const initialRateState: RateState = {
  createLoading: LoadingState.idle,
  loading: LoadingState.idle,
  confirmLoading: LoadingState.idle,
  result: null,
  recruiterData: null,
};
