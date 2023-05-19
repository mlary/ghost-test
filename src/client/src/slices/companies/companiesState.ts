import { CompanyDto } from '~/app/ApiClient';
import LoadingState from '~/types/LoadingState';

export interface CompaniesState {
  loading: LoadingState;
  companies: CompanyDto[];
  recruiterCompanies: CompanyDto[];
  errorMessage?: string;
}
export const initialCompaniesState: CompaniesState = {
  companies: [],
  loading: LoadingState.idle,
  recruiterCompanies: [],
};
