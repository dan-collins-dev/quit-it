<script>
	import trophyIconSrc from "$lib/assets/trophy-svgrepo-com.svg";

	let { lastLog } = $props();
	let date = $derived(lastLog?.date);

	function utcDaysSince(timestampMs) {
		const now = new Date();
		const last = new Date(timestampMs);

		const todayUTC = Date.UTC(now.getUTCFullYear(), now.getUTCMonth(), now.getUTCDate());
		const lastUTC = Date.UTC(last.getUTCFullYear(), last.getUTCMonth(), last.getUTCDate());

		return Math.floor((todayUTC - lastUTC) / 86400000);
	}
</script>

<article class="dashboard-card">
	<div class="logo-container">
		<img class="cig-logo" src={trophyIconSrc} alt="" />
	</div>
	<p class="card-category">Current Streak</p>
	<p class="card-number">{utcDaysSince(date)}</p>
	<p>Last cigarette smoked on {new Date(date).toLocaleDateString()}</p>
</article>

<style>
	article {
		display: flex;
		flex-direction: column;
		align-items: center;
		background-color: #fff;
		border-radius: 5px;
		box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
		padding: 1rem;
		margin: 0.75rem;
		transition: 0.3s;
	}

	article:hover {
		background-color: #d1ccff;
		box-shadow: 0 8px 16px 0 rgba(0, 0, 0, 0.2);
	}

	p {
		color: black;
	}
</style>
