import { PayloadAction, createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import { ApiException, CreateRateCommand, ErrorResponse, IRatesClient, RatesClient } from '~/app/ApiClient';
import LoadingState from '~/types/LoadingState';
import { RecruiterFields } from '~/types/recruiterFields';
import { initialRateState } from './rateState';

const ratesClient: IRatesClient = new RatesClient(process.env.REACT_APP_API_URL);

export const createRate = createAsyncThunk('rate/createRate', async (command: CreateRateCommand) => {
  try {
    const result = await ratesClient.create(command);
    return result;
  } catch (error) {
    if (ApiException.isApiException(error)) {
      throw new Error((error.result as ErrorResponse).errorMessage ?? error.message);
    }
    throw error;
  }
});

export const getRateById = createAsyncThunk('rate/getRateById', async (rateId: number) => {
  try {
    const result = await ratesClient.getById(rateId);
    return result;
  } catch (error) {
    if (ApiException.isApiException(error)) {
      throw new Error((error.result as ErrorResponse).errorMessage ?? error.message);
    }
    throw error;
  }
});

export const confirmRate = createAsyncThunk('rate/confirmRate', async (confirmationId: string) => {
  try {
    await ratesClient.confirm(confirmationId);
  } catch (error) {
    if (ApiException.isApiException(error)) {
      throw new Error((error.result as ErrorResponse).errorMessage ?? error.message);
    }
    throw error;
  }
});
const rateSlice = createSlice({
  name: 'rate',
  initialState: initialRateState,
  reducers: {
    resetRate: () => initialRateState,
    setRecruiterData: (state, { payload }: PayloadAction<RecruiterFields | null>) => {
      state.recruiterData = payload;
    },
  },
  extraReducers: (builder) => {
    // createRate
    builder.addCase(createRate.pending, (state) => {
      state.createLoading = LoadingState.pending;
    });
    builder.addCase(createRate.fulfilled, (state, { payload }) => {
      state.createLoading = LoadingState.succeed;
      state.result = payload;
    });
    builder.addCase(createRate.rejected, (state, { error }) => {
      state.createLoading = LoadingState.failed;
      state.errorMessage = error.message;
    });

    // confirmRate
    builder.addCase(confirmRate.pending, (state) => {
      state.confirmLoading = LoadingState.pending;
    });
    builder.addCase(confirmRate.fulfilled, (state) => {
      state.confirmLoading = LoadingState.succeed;
    });
    builder.addCase(confirmRate.rejected, (state, { error }) => {
      state.confirmLoading = LoadingState.failed;
      state.errorMessage = error.message;
    });

    // getRateById
    builder.addCase(getRateById.pending, (state) => {
      state.loading = LoadingState.pending;
    });
    builder.addCase(getRateById.fulfilled, (state, { payload }) => {
      state.loading = LoadingState.succeed;
      state.result = payload;
    });
    builder.addCase(getRateById.rejected, (state) => {
      state.loading = LoadingState.failed;
    });
  },
});
export const { resetRate, setRecruiterData } = rateSlice.actions;
export default rateSlice.reducer;
