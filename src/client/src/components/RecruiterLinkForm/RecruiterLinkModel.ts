import * as yup from 'yup';
import { EMAIL_EXPRESSION, URL_EXPRESSION } from '~/const/regexExpressions';
import { VALIDATION_MESSAGES } from '~/const/validationMessages';

export type RecruiterLinkFormData = {
  linkedInUrl: string;
  companyName: string | undefined;
  companyId?: number;
  email: string;
};

export const initialRecruiterLinkData: RecruiterLinkFormData = {
  linkedInUrl: '',
  companyName: '',
  email: '',
};

export const recruiterLinkSchema = yup.object().shape({
  linkedInUrl: yup
    .string()
    .required(VALIDATION_MESSAGES.enterRequiredField)
    .matches(URL_EXPRESSION, VALIDATION_MESSAGES.enterValidUrl),
  email: yup
    .string()
    .required(VALIDATION_MESSAGES.enterRequiredField)
    .matches(EMAIL_EXPRESSION, VALIDATION_MESSAGES.enterValidEmail),
  companyName: yup.string().nullable().notRequired(),
});
