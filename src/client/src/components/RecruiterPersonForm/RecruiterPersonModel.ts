import * as yup from 'yup';
import { VALIDATION_MESSAGES } from '~/const/validationMessages';

export type RecruiterPersonFormData = {
  firstName: string;
  surname: string;
};

export const initialRecruiterPersonData: RecruiterPersonFormData = {
  firstName: '',
  surname: '',
};

export const recruiterPersonSchema = yup.object().shape({
  firstName: yup.string().required(VALIDATION_MESSAGES.enterRequiredField),
  surname: yup.string().required(VALIDATION_MESSAGES.enterRequiredField),
});
