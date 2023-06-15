import * as yup from 'yup';
import { AnswerTypes, PositionSeniorityLevels } from '~/app/ApiClient';
import { EMAIL_EXPRESSION } from '~/const/regexExpressions';
import { VALIDATION_MESSAGES } from '~/const/validationMessages';

export type RateFormData = {
  commonRating?: number;
  interviewRound?: number;
  positionSeniorityLevel?: PositionSeniorityLevels;
  lateInMinutes?: number;
  cancelledInterview?: boolean;
  interviewerListeningRate?: number;
  interviewerInterestRate?: number;
  comment?: string;
  visitedLinkedInProfile?: AnswerTypes;
  questionsRate?: number;
  email: string;
};

export const initialRateFormData: RateFormData = {
  comment: '',
  visitedLinkedInProfile: AnswerTypes.Unknown,
  email: '',
};
export const rateFormSchema = yup.object().shape({
  commonRating: yup.number().required(VALIDATION_MESSAGES.enterRequiredField),
  interviewRound: yup.number().required(VALIDATION_MESSAGES.enterRequiredField),
  positionSeniorityLevel: yup.string().required(VALIDATION_MESSAGES.enterRequiredField),
  cancelledInterview: yup.boolean().required(VALIDATION_MESSAGES.enterRequiredField),
  lateInMinutes: yup.number(),
  interviewerListeningRate: yup.number().when('cancelledInterview', {
    is: false,
    then: yup.number().required(VALIDATION_MESSAGES.enterRequiredField),
  }),
  interviewerInterestRate: yup.number().when('cancelledInterview', {
    is: false,
    then: yup.number().required(VALIDATION_MESSAGES.enterRequiredField),
  }),
  comment: yup.string(),
  questionsRate: yup.number().when('cancelledInterview', {
    is: false,
    then: yup.number().required(VALIDATION_MESSAGES.enterRequiredField),
  }),
  visitedLinkedInProfile: yup.string(),
  email: yup
    .string()
    .required(VALIDATION_MESSAGES.enterRequiredField)
    .matches(EMAIL_EXPRESSION, VALIDATION_MESSAGES.enterValidEmail),
});
