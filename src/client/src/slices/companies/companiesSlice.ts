import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import { CompaniesClient, ICompaniesClient } from '~/app/ApiClient';
import LoadingState from '~/types/LoadingState';
import { initialCompaniesState } from './companiesState';

const companyClient: ICompaniesClient = new CompaniesClient(process.env.REACT_APP_API_URL);

export const getCompanies = createAsyncThunk('company/getCompanies', async () => {
  const result = await companyClient.getAll();
  return result;
});


export const getCompaniesByRecruiter = createAsyncThunk('company/getCompaniesByRecruiter', async (recruiterId: number) => {
  const result = await companyClient.getByRecruiterId(recruiterId);
  return result;
});

const companiesSlice = createSlice({
  name: 'companies',
  initialState: initialCompaniesState,
  reducers: {
    resetCompanies: () => initialCompaniesState,
  },
  extraReducers: (builder) => {
    builder.addCase(getCompanies.pending, (state) => {
      state.loading = LoadingState.pending;
      state.companies = [];
    });
    builder.addCase(getCompanies.fulfilled, (state, { payload }) => {
      state.loading = LoadingState.succeed;
      state.companies = payload;
    });
    builder.addCase(getCompanies.rejected, (state, { error }) => {
      state.loading = LoadingState.failed;
      state.errorMessage = error.message;
    });

    builder.addCase(getCompaniesByRecruiter.pending, (state) => {
      state.loading = LoadingState.pending;
      state.recruiterCompanies = [];
    });
    builder.addCase(getCompaniesByRecruiter.fulfilled, (state, { payload }) => {
      state.loading = LoadingState.succeed;
      state.recruiterCompanies = payload;
    });
    builder.addCase(getCompaniesByRecruiter.rejected, (state, { error }) => {
      state.loading = LoadingState.failed;
      state.errorMessage = error.message;
    });
  },
});
export const { resetCompanies } = companiesSlice.actions;
export default companiesSlice.reducer;
