/** @jsxImportSource @emotion/react */
import { css } from '@emotion/react';
import { Tooltip } from '@mui/material';
import Logo from '../../assets/images/ghost.png';

const classes = {
  root: css({
    display: 'flex',
    gap: 10,
    padding: '4px 8px',
    width: 'auto',
  }),
  logo: css({
    width: 40,
    opacity: 0.3,
    cursor: 'pointer',
  }),
  selected: css({
    opacity: 1,
  }),
};
type GhostRateProps = {
  value?: number;
  className?: string;
  size?: number;
  disableMiddle?: boolean;
  isDisabled?: boolean;
  onChange?: (value: number) => void;
};

const RATE_VALUES = [
  { rate: 1, label: 'Super ghosted me' },
  { rate: 2, label: 'Ghosted me' },
  { rate: 3, label: 'Not selectable' },
  { rate: 4, label: 'Some what comunicated' },
  { rate: 5, label: 'Comunicated clearly and consistanty' },
];
const GhostRate = ({ value, onChange, className, isDisabled, size, disableMiddle = true }: GhostRateProps) => {
  const handleClick = (rate: number) => () => {
    if ((disableMiddle && rate === 3) || isDisabled) {
      return;
    }
    if (onChange) {
      onChange(rate);
    }
  };
  return (
    <div css={classes.root} className={className}>
      {RATE_VALUES.map(({ rate, label }) => (
        <Tooltip title={label}>
          <img
            key={`rate-${rate}`}
            onClick={handleClick(rate)}
            style={{ width: size }}
            src={Logo}
            css={[classes.logo, value && value >= rate && classes.selected]}
          />
        </Tooltip>
      ))}
    </div>
  );
};
export default GhostRate;
