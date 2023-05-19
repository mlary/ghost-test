import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import { CompaniesClient, CreateCompanyCommand, ICompaniesClient } from '~/app/ApiClient';
import LoadingState from '~/types/LoadingState';
import { initialCompanyState } from './companyState';

const companyClient: ICompaniesClient = new CompaniesClient(process.env.REACT_APP_API_URL);

export const createCompany = createAsyncThunk('company/createCompany', async (command: CreateCompanyCommand) => {
  const result = await companyClient.create(command);
  return result;
});

export const getCompanyByName = createAsyncThunk('company/getCompanyByName', async (value: string) => {
  const result = await companyClient.getByName(value);
  return result;
});

const companySlice = createSlice({
  name: 'company',
  initialState: initialCompanyState,
  reducers: {
    resetCompany: () => initialCompanyState,
  },
  extraReducers: (builder) => {
    // createCompany
    builder.addCase(createCompany.pending, (state) => {
      state.loading = LoadingState.pending;
      state.company = null;
    });
    builder.addCase(createCompany.fulfilled, (state, { payload }) => {
      state.loading = LoadingState.succeed;
      state.company = payload;
    });
    builder.addCase(createCompany.rejected, (state, { error }) => {
      state.loading = LoadingState.failed;
      state.errorMessage = error.message;
    });

     // getCompanyByName
     builder.addCase(getCompanyByName.pending, (state) => {
        state.loading = LoadingState.pending;
        state.company = null;
      });
      builder.addCase(getCompanyByName.fulfilled, (state, { payload }) => {
        state.loading = LoadingState.succeed;
        state.company = payload;
      });
      builder.addCase(getCompanyByName.rejected, (state, { error }) => {
        state.loading = LoadingState.failed;
        state.errorMessage = error.message;
      });
  },
});
export const { resetCompany } = companySlice.actions;
export default companySlice.reducer;
