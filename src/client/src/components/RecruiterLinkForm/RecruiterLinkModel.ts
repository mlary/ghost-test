import * as yup from 'yup';
import { VALIDATION_MESSAGES } from '~/const/validationMessages';

export type RecruiterLinkFormData = {
  linkedInUrl: string;
  companyName: string | undefined;
  companyId?: number;
};
const EXAMPLE_LINK = "Example: https://www.linkedin.com/in/brucewayne23/";
export const initialRecruiterLinkData: RecruiterLinkFormData = {
  linkedInUrl: '',
  companyName: '',
};

export const recruiterLinkSchema = yup.object().shape({
  linkedInUrl: yup
    .string()
    .required(`${VALIDATION_MESSAGES.enterRequiredField}. ${EXAMPLE_LINK}`)
    .test(
      'linkedinMatch',
      `${VALIDATION_MESSAGES.enterValidUrl}. ${EXAMPLE_LINK}`,
      (value) => value?.includes('linkedin.com/in/') ?? false,
    ),
  companyName: yup.string().nullable().notRequired(),
});
