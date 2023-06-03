import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import { IUsersClient, UsersClient } from '~/app/ApiClient';
import LoadingState from '~/types/LoadingState';
import { initialRecaptchaState } from './recaptchaState';

const userClient: IUsersClient = new UsersClient(process.env.REACT_APP_API_URL);

export const validateCaptcha = createAsyncThunk('recaptcha/validate', async (token: string) => {
  const result = userClient.verify(token);
  return result;
});
const recaptchaSlice = createSlice({
  name: 'recaptcha',
  initialState: initialRecaptchaState,
  reducers: {
    resetRecaptcha: () => initialRecaptchaState,
  },
  extraReducers: (builder) => {
    builder.addCase(validateCaptcha.pending, (state) => {
      state.loading = LoadingState.pending;
      state.result = null;
    });
    builder.addCase(validateCaptcha.fulfilled, (state, {payload}) => {
      state.loading = LoadingState.succeed;
      state.result = payload;
    });
    builder.addCase(validateCaptcha.rejected, (state) => {
      state.loading = LoadingState.failed;
    });
  },
});
export const { resetRecaptcha } = recaptchaSlice.actions;

export default recaptchaSlice.reducer;
