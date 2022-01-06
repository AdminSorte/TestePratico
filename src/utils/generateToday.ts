interface GenerateToday {
  date: string
  hour: string
}

export function generateToday(): GenerateToday {
  const today = new Date()
  const date = today.getDate()
  const month = today.getMonth() + 1
  const year = today.getFullYear()
  const hour = today.getHours()
  const minute = today.getMinutes()

  const formatdDate = date < 10 ? `0${date}` : date
  const formatedMonth = month < 10 ? `0${month}` : month

  const dateString = `${formatdDate}/${formatedMonth}/${year}`
  const hourString = `${hour}:${minute}`

  return {
    date: dateString,
    hour: hourString,
  }
}
