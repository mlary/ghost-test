/** @jsxImportSource @emotion/react */
import { css } from '@emotion/react';
import { Card } from '@mui/material';
import { useEffect } from 'react';
import { useParams } from 'react-router';
import { useAppDispatch, useAppSelector } from '~/app/store';
import GhostRate from '~/components/GhostRate/GhostRate';
import { confirmRate, getRateById } from '~/slices/rate/rateSlice';

const classes = {
  root: css({
    width: '100%',
    alignItems: 'center',
    display: 'flex',
    justifyContent: 'center',
  }),
  header: css({
    textAlign: "center",
    fontSize: '2rem',
  }),
  rate:css({
    alignSelf: "center",
  }),
  card: css({
    display: 'flex',
    padding: 16,
    flexDirection: 'column',
    gap: 8,
    minWidth: 320,
    maxWidth: 1200,
  }),
};
const ConfirmRate = () => {
  const { confirmationId, rateId } = useParams<{ rateId: string; confirmationId: string }>();
  const { result: currentRate } = useAppSelector((state) => state.rate);
  const dispatch = useAppDispatch();
  useEffect(() => {
    if (rateId) {
      dispatch(getRateById(Number(rateId)));
    }
  }, [rateId]);

  useEffect(() => {
    if (confirmationId) {
      dispatch(confirmRate(confirmationId));
    }
  }, [confirmationId]);

  return (
    <div css={classes.root}>
      <Card css={classes.card}>
        {!confirmationId && !currentRate?.isConfirmed && (
          <h2 css={classes.header}>
            Click link in your email to confirm your review.
            <p>Thank you!</p>
          </h2>
        )}
        {(confirmationId || currentRate?.isConfirmed) && (
          <h2 css={classes.header}>
            Your rate is successfully confirmed.
            <p>Thank you!</p>
          </h2>
        )}
        <GhostRate css={classes.rate} size={64} value={currentRate?.commonRating} />
      </Card>
    </div>
  );
};

export default ConfirmRate;
