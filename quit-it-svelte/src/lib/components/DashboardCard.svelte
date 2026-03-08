<script>
	let { iconSrc, label, count } = $props();
</script>

<article class="dashboard-card">
	<div class="logo-container">
		<img class="cig-logo" src={iconSrc} alt="" />
	</div>
	<p class="card-category">{label}</p>
	<p class="card-number">{count}</p>
	<!-- <p>{data.log}</p> -->
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
</style>
