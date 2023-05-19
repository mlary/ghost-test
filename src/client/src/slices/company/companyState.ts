import { CompanyDto } from '~/app/ApiClient';
import LoadingState from '~/types/LoadingState';

export interface CompanyState {
  loading: LoadingState;
  company: CompanyDto | null;
  errorMessage?: string;
}
export const initialCompanyState: CompanyState = {
  company: null,
  loading: LoadingState.idle,
};
