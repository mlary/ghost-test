import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import { CreateOrUpdateRequiterCommand, IRecruitersClient, RecruitersClient } from '~/app/ApiClient';
import LoadingState from '~/types/LoadingState';
import { initialRecruiterState } from './recruiterState';

const recruitersClient: IRecruitersClient = new RecruitersClient(process.env.REACT_APP_API_URL);

export const getRecruiterByLinkedInProfileId = createAsyncThunk('recruiters/getByProfileId', async (profileId: string) => {
  const result = await recruitersClient.getByProfileId(profileId);
  return result;
});


export const getRecruiterById = createAsyncThunk('recruiters/getRecruiterById', async (id: number) => {
  const result = await recruitersClient.getById(id);
  return result;
});


export const createRecruiter = createAsyncThunk(
  'recruiters/createRecruiter',
  async (command: CreateOrUpdateRequiterCommand) => {
    const result = await recruitersClient.createOrUpdate(command);
    return result;
  },
);

const recruiterSlice = createSlice({
  name: 'recruiters',
  initialState: initialRecruiterState,
  reducers: {
    resetRecruiters: () => initialRecruiterState,
  },
  extraReducers: (builder) => {
    // getRecruiterByLinkedInProfileId
    builder.addCase(getRecruiterByLinkedInProfileId.pending, (state) => {
      state.getRecruiterLoading = LoadingState.pending;
    });
    builder.addCase(getRecruiterByLinkedInProfileId.fulfilled, (state, { payload }) => {
      state.getRecruiterLoading = LoadingState.succeed;
      state.targetRecruiter = payload;
    });
    builder.addCase(getRecruiterByLinkedInProfileId.rejected, (state, { error }) => {
      state.getRecruiterLoading = LoadingState.succeed;
      state.errorMessage = error.message;
    });

    // getRecruiterById
    builder.addCase(getRecruiterById.pending, (state) => {
      state.getRecruiterLoading = LoadingState.pending;
    });
    builder.addCase(getRecruiterById.fulfilled, (state, { payload }) => {
      state.getRecruiterLoading = LoadingState.succeed;
      state.targetRecruiter = payload;
    });
    builder.addCase(getRecruiterById.rejected, (state, { error }) => {
      state.getRecruiterLoading = LoadingState.succeed;
      state.errorMessage = error.message;
    });

    // createRecruiter
    builder.addCase(createRecruiter.pending, (state) => {
      state.createRecruiterLoading = LoadingState.pending;
    });
    builder.addCase(createRecruiter.fulfilled, (state, { payload }) => {
      state.createRecruiterLoading = LoadingState.succeed;
      state.targetRecruiter = payload;
    });
    builder.addCase(createRecruiter.rejected, (state, { error }) => {
      state.createRecruiterLoading = LoadingState.succeed;
      state.errorMessage = error.message;
    });
  },
});
export const { resetRecruiters } = recruiterSlice.actions;
export default recruiterSlice.reducer;
