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

  const dateString = `${date}/${month}/${year}`
  const hourString = `${hour}:${minute}`

  return {
    date: dateString,
    hour: hourString,
  }
}
