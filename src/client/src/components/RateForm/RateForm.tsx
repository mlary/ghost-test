/** @jsxImportSource @emotion/react */
import { css } from '@emotion/react';
import { Button, Card, FormControlLabel, MenuItem, Radio, RadioGroup, Select, Slider, TextField } from '@mui/material';

import { FormikProvider, useFormik } from 'formik';
import { useCallback, useEffect } from 'react';
import { useNavigate } from 'react-router';
import { AnswerTypes, PositionSeniorityLevels } from '~/app/ApiClient';
import { useAppDispatch, useAppSelector } from '~/app/store';
import { getCompaniesByRecruiter } from '~/slices/companies/companiesSlice';
import { createRate } from '~/slices/rate/rateSlice';
import LoadingState from '~/types/LoadingState';
import { getFormikErrorProps, getFormikFieldProps } from '~/utils/formikHelper';
import DotsRate from '../DotsRate/DotsRate';
import GhostRate from '../GhostRate/GhostRate';
import HelperText from '../HelperText/HelperText';
import { RateFormData, rateFormSchema, initialRateFormData } from './RateFormSchema';

const classes = {
  root: css({
    minWidth: 400,
    maxWidth: 1200,
    width: '100%',
  }),
  card: css({
    display: 'flex',
    padding: 16,
    flexDirection: 'column',
    gap: 8,
  }),
  container: css({
    display: 'flex',
    gap: 20,
  }),
  roundSelect: css({
    width: 150,
  }),
  rateForm: css({
    flexDirection: 'column',
    width: '80%',
    gap: 20,
    alignItems: 'center',
  }),
  formItem: css({
    width: '100%',
    paddingTop: 8,
  }),
  label: css({
    fontWeight: 600,
  }),
  actions: css({
    display: 'flex',
    justifyContent: 'flex-end',
    width: '100%',
  }),
  sliderWrapper: css({
    display: 'flex',
    width: '50%',
    gap: 16,
    alignItems: 'center',
  }),
  slider: css({
    width: '70%',
  }),
  nextBtn: css({
    minWidth: 100,
  }),
  header: css({
    fontSize: '2rem',
    textAlign: 'center',
  }),
  selectWrapper: css({
    width: '100%',
    display: 'flex',
    gap: 16,
  }),
  positionSelect: css({
    width: 300,
  }),
  profileWrapper: css({
    width: 300,
    flexDirection: 'column',
    gap: 20,
    padding: 4,
  }),
  profile: css({
    display: 'flex',
    width: '100%',
    padding: 8,
    flexDirection: 'column',
    gap: 8,
    justifyContent: 'center',
    border: '2px solid var(--bg-main)',
    borderRadius: 10,
  }),
};

const POSITION_OPTIONS = [
  { value: PositionSeniorityLevels.EntryLevel, title: 'Entry level' },
  { value: PositionSeniorityLevels.MidSeniorLevel, title: 'Mid senior level' },
  { value: PositionSeniorityLevels.SeniorLevel, title: 'Senior level' },
  { value: PositionSeniorityLevels.CLevel, title: 'C-level' },
];
const RateForm = () => {
  const dispatch = useAppDispatch();
  const { targetRecruiter } = useAppSelector((state) => state.recruiter);
  const { recruiterCompanies } = useAppSelector((state) => state.companies);
  const { recruiterData, createLoading, result: currentRate } = useAppSelector((state) => state.rate);
  const navigate = useNavigate();

  useEffect(() => {
    if (targetRecruiter?.id) {
      dispatch(getCompaniesByRecruiter(targetRecruiter?.id));
    }
  }, [targetRecruiter]);
  useEffect(() => {
    if (createLoading === LoadingState.succeed && currentRate) {
      navigate(`/confirmation/${currentRate.id}`);
    }
  }, [createLoading]);
  const handleSubmit = useCallback((values: RateFormData) => {
    if (recruiterData && targetRecruiter) {
      dispatch(
        createRate({
          recruitingType: 0,
          recruiterId: targetRecruiter.id,
          email: recruiterData.email,
          companyName: recruiterData?.companyName,
          commonRating: values.commonRating ?? 0,
          interviewRound: values.interviewRound ?? 0,
          positionSeniorityLevel: values.positionSeniorityLevel ?? PositionSeniorityLevels.EntryLevel,
          lateInMinutes: values.lateInMinutes ?? 0,
          cancelledInterview: values.cancelledInterview ?? false,
          interviewerListeningRate: values.interviewerListeningRate ?? 0,
          interviewerInterestRate: values.interviewerInterestRate ?? 0,
          comment: values.comment ?? '',
          visitedLinkedInProfile: values.visitedLinkedInProfile ?? AnswerTypes.Unknown,
          questionsRate: values.questionsRate ?? 0,
        }),
      );
    }
  }, []);

  const formik = useFormik({
    initialValues: initialRateFormData,
    validationSchema: rateFormSchema,
    onSubmit: handleSubmit,
  });

  return (
    <FormikProvider value={formik}>
      <div css={classes.root}>
        <form onSubmit={formik.submitForm} autoComplete="off">
          <Card css={classes.card}>
            <h2 css={classes.header}>Enter rate information</h2>
            <div css={classes.container}>
              <div css={classes.profileWrapper}>
                <div css={classes.profile}>
                  <div>
                    <a href={recruiterData?.linkedInUrl} target="_blank">
                      Entered LinkedIn link
                    </a>
                  </div>
                  <div>
                    <div>{`${targetRecruiter?.firstName ?? ''} ${targetRecruiter?.surname ?? ''}`}</div>
                  </div>
                  {recruiterData?.companyName && <div>{recruiterData?.companyName}</div>}
                  {recruiterCompanies.length > 1 && (
                    <div>
                      Also associated with:
                      <div>
                        {recruiterCompanies
                          .filter((company) => company.name !== recruiterData?.companyName)
                          .map((row) => row.name)
                          .join(', ')}
                      </div>
                    </div>
                  )}
                </div>
                <div css={classes.formItem}>
                  <div css={classes.label}>Visited LinkedIn</div>
                  <RadioGroup
                    row
                    value={formik.values.visitedLinkedInProfile}
                    name="visitedLinkedInProfile"
                    onChange={(e) => {
                      formik.setFieldValue('visitedLinkedInProfile', e.target.value);
                    }}>
                    <FormControlLabel value={AnswerTypes.Yes} control={<Radio />} label="Yes" />
                    <FormControlLabel value={AnswerTypes.No} control={<Radio />} label="No" />
                    <FormControlLabel value={AnswerTypes.Unknown} control={<Radio />} label="I don't know" />
                  </RadioGroup>
                  <HelperText {...getFormikErrorProps(formik, 'visitedLinkedInProfile')} />
                </div>
              </div>

              <div css={classes.rateForm}>
                <div css={classes.formItem}>
                  <GhostRate
                    value={formik.values.commonRating}
                    onChange={(rate) => {
                      formik.setFieldValue('commonRating', rate);
                    }}
                    size={40}
                  />
                  <HelperText {...getFormikErrorProps(formik, 'commonRating')} />
                </div>
                <div css={classes.selectWrapper}>
                  <div>
                    <div css={classes.label}>Interview round</div>
                    <Select css={classes.roundSelect} {...getFormikFieldProps(formik, 'interviewRound')}>
                      {[1, 2, 3, 4, 5].map((round) => (
                        <MenuItem key={`round-${round}`} value={round}>
                          {round}
                        </MenuItem>
                      ))}
                    </Select>
                    <HelperText {...getFormikErrorProps(formik, 'interviewRound')} />
                  </div>
                  <div>
                    <div css={classes.label}>Position seniority level</div>
                    <Select
                      css={classes.positionSelect}
                      fullWidth
                      {...getFormikFieldProps(formik, 'positionSeniorityLevel')}>
                      {POSITION_OPTIONS.map(({ value, title }) => (
                        <MenuItem key={`round-${value}`} value={value}>
                          {title}
                        </MenuItem>
                      ))}
                    </Select>
                    <HelperText {...getFormikErrorProps(formik, 'positionSeniorityLevel')} />
                  </div>
                </div>
                <div css={classes.formItem}>
                  <div css={classes.label}>Intervier late</div>
                  <div css={classes.sliderWrapper}>
                    <span>0</span>
                    <Slider
                      css={classes.slider}
                      value={formik.values.lateInMinutes}
                      onChange={(_, value) => {
                        formik.setFieldValue('lateInMinutes', value);
                      }}
                    />
                    <span>30+ Min</span>
                  </div>
                </div>
                <div css={classes.formItem}>
                  <div css={classes.label}>
                    Cancelled few minutes before or at a time of scheduled interview or no show
                  </div>
                  <RadioGroup
                    row
                    value={formik.values.cancelledInterview}
                    name="radio-buttons-group"
                    onChange={(e) => {
                      formik.setFieldValue('cancelledInterview', e.target.value);
                    }}>
                    <FormControlLabel value={true} control={<Radio />} label="Yes" />
                    <FormControlLabel value={false} control={<Radio />} label="No" />
                  </RadioGroup>
                  <HelperText {...getFormikErrorProps(formik, 'cancelledInterview')} />
                </div>
                <div css={classes.formItem}>
                  <div css={classes.label}>Questions in interview were alligned with job description</div>
                  <DotsRate
                    value={formik.values.questionsRate}
                    onChange={(e) => {
                      formik.setFieldValue('questionsRate', e);
                    }}
                    leftLabel="Not at all"
                    rightLabel="Alligned"
                  />
                  <HelperText {...getFormikErrorProps(formik, 'questionsRate')} />
                </div>
                <div css={classes.formItem}>
                  <div css={classes.label}>Interviewer spend more time talking than listening</div>
                  <DotsRate
                    value={formik.values.interviewerListeningRate}
                    onChange={(e) => {
                      formik.setFieldValue('interviewerListeningRate', e);
                    }}
                    leftLabel="Not at all"
                    rightLabel="Talking over you"
                  />
                  <HelperText {...getFormikErrorProps(formik, 'interviewerListeningRate')} />
                </div>
                <div css={classes.formItem}>
                  <div css={classes.label}>
                    Interviewe seemed to be preocupied with something (not patying attention to your answers)
                  </div>
                  <DotsRate
                    value={formik.values.interviewerInterestRate}
                    onChange={(e) => {
                      formik.setFieldValue('interviewerInterestRate', e);
                    }}
                    leftLabel="Not at all"
                    rightLabel="Interviewer was focused on my answers and taking notes"
                  />
                  <HelperText {...getFormikErrorProps(formik, 'interviewerInterestRate')} />
                </div>
                <div css={classes.formItem}>
                  <div css={classes.label}>Additional notes</div>
                  <TextField
                    fullWidth
                    multiline
                    rows={3}
                    required
                    placeholder="Additional notes here (profanity strictly inforced) 240 ch"
                    {...getFormikFieldProps(formik, 'comment')}
                  />
                </div>
              </div>
            </div>
            <div css={classes.actions}>
              <Button onClick={formik.submitForm} color="primary" variant="contained" css={classes.nextBtn}>
                Submit
              </Button>
            </div>
          </Card>
        </form>
      </div>
    </FormikProvider>
  );
};
export default RateForm;
