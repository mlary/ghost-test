/** @jsxImportSource @emotion/react */
import { css } from '@emotion/react';
import { FormControlLabel, Radio, RadioGroup } from '@mui/material';

const classes = {
  root: css({
    display: 'flex',
    gap: 8,
    alignItems: 'center',
  }),
  title: css({
    fontSize: '1rem',
  }),
  dots: css({
    '& label:last-child': css({
      marginRight: 0,
    }),
    "& .MuiButtonBase-root":css({
      '@media (max-width: 420px)': css({
        padding: 4,
      }),
    }),
    '& label':css({
      '@media (max-width: 700px)': css({
        marginRight: 8,
      }),
    })
  }),
  rightLabel:css({
    '@media (max-width: 700px)': css({
      maxWidth: 300,
    }),
    '@media (max-width: 600px)': css({
      maxWidth: 200,
    }),
    '@media (max-width: 550px)': css({
      maxWidth: 100,
    }),
    '@media (max-width: 400px)': css({
      maxWidth: 80,
    }),
  })
};

type DotsRateProps = {
  value?: number;
  onChange: (value: number) => void;
  leftLabel: string;
  rightLabel: string;
};
const OPTOIN_VALUES = [1, 2, 3, 4, 5];
const DotsRate = ({ leftLabel, onChange, rightLabel, value }: DotsRateProps) => {
  const handleChanged = (_: unknown, data: string) => {
    onChange(Number(data));
  };
  return (
    <div css={classes.root}>
      <span>{leftLabel}</span>
      <RadioGroup
        css={classes.dots}
        row
        defaultValue={null}
        value={value}
        name="radio-buttons-group"
        onChange={handleChanged}>
        {OPTOIN_VALUES.map((option) => (
          <FormControlLabel label="" value={option} control={<Radio />} />
        ))}
      </RadioGroup>
      <span css={classes.rightLabel}>{rightLabel}</span>
    </div>
  );
};
export default DotsRate;
