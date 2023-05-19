/** @jsxImportSource @emotion/react */
import { css } from '@emotion/react';

import { useEffect } from 'react';
import { useNavigate } from 'react-router';
import { useAppSelector } from '~/app/store';
import RateForm from '~/components/RateForm/RateForm';

const classes = {
  root: css({
    alignItems: 'center',
    display: 'flex',
    justifyContent: 'center',
    height: '100%',
  }),
};

const Rate = () => {
  const { targetRecruiter } = useAppSelector((state) => state.recruiter);
  const navigate = useNavigate();
  useEffect(() => {
    // go to home if recruiter does not selected
    if (!targetRecruiter) {
      navigate('/');
    }
  }, [targetRecruiter]);

  return (
    <div css={classes.root}>
      <RateForm />
    </div>
  );
};
export default Rate;
