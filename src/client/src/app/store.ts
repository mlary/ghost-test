import { configureStore, ThunkAction, Action } from '@reduxjs/toolkit';
import { TypedUseSelectorHook, useDispatch, useSelector } from 'react-redux';
import companies from '@slices/companies/companiesSlice';
import company from '@slices/company/companySlice';
import rate from '@slices/rate/rateSlice';
import recruiter from '@slices/recruiter/recruiterSlice';

export const store = configureStore({
  reducer: {
    rate,
    companies,
    company,
    recruiter,
  },
});
export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;
export type AppThunk<ReturnType = void> = ThunkAction<ReturnType, RootState, unknown, Action<string>>;

export const useAppDispatch = () => useDispatch<AppDispatch>();
export const useAppSelector: TypedUseSelectorHook<RootState> = useSelector;
