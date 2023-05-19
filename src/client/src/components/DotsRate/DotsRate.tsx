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
    '& label:last-child': {
      marginRight: 0,
    },
  }),
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
      <span>{rightLabel}</span>
    </div>
  );
};
export default DotsRate;
